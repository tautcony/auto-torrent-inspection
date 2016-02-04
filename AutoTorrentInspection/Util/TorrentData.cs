﻿using System;

using System.Linq;
using System.Text;
using BencodeNET;
using BencodeNET.Objects;
using System.Collections.Generic;
using System.Diagnostics;

namespace AutoTorrentInspection.Util
{
    public class TorrentData
    {
        private readonly TorrentFile _torrent;

        public TorrentData(string path)
        {
            _torrent = Bencode.DecodeTorrentFile(path);
        }

        public IEnumerable<string> GetAnnounceList() => _torrent.AnnounceList?.ToList().Select(item => ((BList)item).First().ToString()).ToList() ?? new List<string> { _torrent.Announce };

        public string CreatedBy => _torrent.CreatedBy;

        public DateTime CreationDate
        {
            get
            {
                TimeSpan timeZoneOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                DateTime utcTime = _torrent.CreationDate;
                return utcTime.Add(timeZoneOffset);
            }
        }

        public string Comment => _torrent.Comment;

        public string Source => _torrent.Info.ContainsKey("source") ? _torrent.Info["source"].ToString() : "";

        public string TorrentName => _torrent.Info["name"].ToString();

        public bool IsPrivate
        {
            get
            {
                var pri = _torrent.Info["private"];
                return pri != null && (BNumber) pri != 0 && (BNumber) pri == 1;
            }
        }

        public Dictionary<string, List<FileDescription>> GetFileList()
        {
            var fileDic = new Dictionary<string, List<FileDescription>>();
            var files = (BList)_torrent.Info["files"];
            if (files == null)
            {
                var name    = _torrent.Info["name"].ToString();
                var length  = ((BNumber) _torrent.Info["length"]).Value;
                fileDic.Add("single", new List<FileDescription> { new FileDescription(name, "", length) });
                return fileDic;
            }
            foreach (var bObject in files)
            {
                var singleFile = (BList) ((BDictionary) bObject)["path"];
                var length     = ((BNumber) ((BDictionary) bObject)["length"]).Value;
                var category   = singleFile.Count != 1 ? singleFile.First().ToString() : "root";
                var path = new StringBuilder();
                for (int i = 0; i < singleFile.Count - 1; i++)
                {
                    path.Append($"{singleFile[i]}\\");
                }
                //var path = singleFile.Aggregate(new StringBuilder(), (current, item) => current.Append($"{item}\\"));
                var name = singleFile.Last().ToString();
                if (name.Contains("_____padding_file_")) continue;
                //reason: https://www.ptt.cc/bbs/P2PSoftWare/M.1191552305.A.5CE.html

                fileDic.TryAdd(category, new List<FileDescription>());
                fileDic[category].Add(new FileDescription(name, path.ToString(), length));
            }
            return fileDic;
        }
    }
}