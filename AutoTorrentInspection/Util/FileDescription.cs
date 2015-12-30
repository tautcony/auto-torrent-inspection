﻿using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace AutoTorrentInspection.Util
{
    public class FileDescription
    {
        public string FileName  { set; private get; }
        public string Path      { set; private get; }
        public string Ext       { set; private get; }
        public long Length      { set; private get; }
        public bool InValidFile { private set; get; }


        private readonly Regex _animePartten = new Regex(@"^\[[^\[\]]*VCB-S(?:tudio)*[^\[\]]*\] [^\[\]]+ (\[.*\d*\])*\[((?<Ma>Ma10p_1080p)|(?<Hi>(Hi10p|Hi444pp)_(1080|720|480)p)|(?<EIGHT>(1080|720)p))\]\[((?<HEVC-Ma>x265)|(?<AVC-Hi>x264)|(?(EIGHT)x264))_\d*(flac|aac|ac3)\](?<SUB>(\.(sc|tc)|\.(chs|cht))*)\.((?(AVC)(mkv|mka|flac))|(?(HEVC)(mkv|mka|flac)|(?(EIGHT)mp4))|(?(SUB)ass))$");
        private readonly Regex _musicPartten = new Regex(@"\.(flac|tak|m4a|cue|log|jpg|jpeg|jp2)");
        private readonly Regex _exceptPartten = new Regex(@"\.(rar|7z|zip)");


        public bool CheckValid()
        {
            InValidFile = !_exceptPartten.IsMatch(Ext.ToLower()) &&
                          !_musicPartten.IsMatch(FileName.ToLower()) &&
                          !_animePartten.IsMatch(FileName);
            return InValidFile;
        }

        public override string ToString() => $"{FileName}, length: {(double)Length / 1024:F3}KB";

        public DataGridViewRow ToRow(DataGridView view)
        {
            var row = new DataGridViewRow();
            row.CreateCells(view, Path, FileName, $"{(double)Length / 1024:F3}KB");
            row.DefaultCellStyle.BackColor = ColorTranslator.FromHtml(InValidFile ? "#FB9966" : "#92AAF3");
            return row;
        }
    }
}