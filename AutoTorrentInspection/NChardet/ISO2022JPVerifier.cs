﻿namespace NChardet
{
    /// <summary>
    /// Description of ISO2022JPVerifier.
    /// </summary>
    public sealed class ISO2022JPVerifier : Verifier
    {
        static int[]  _cclass   ;
        static int[]  _states   ;
        static int    _stFactor ;
        static string _charset  ;

        public override int[]  cclass()   { return _cclass ;   }
        public override int[]  states()   { return _states ;   }
        public override int    stFactor() { return _stFactor ; }
        public override string charset()  { return _charset ;  }

        public ISO2022JPVerifier()
        {
            _cclass = new int[256/8] ;
            _cclass[0]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (2))) )))))) ;
            _cclass[1]  = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[2]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[3]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((1) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[4]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 7))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[5]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (3))) )))))) ;
            _cclass[6]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[7]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[8]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (4))) ) << 8) | (   ((int)(((0) << 4) | (6))) )))))) ;
            _cclass[9]  = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (5))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[10] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[11] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[12] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[13] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[14] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[15] = ((int)(((  ((int)(((  ((int)((( 0) << 4) | (0)))  ) << 8) | (((int)(((0) << 4) | ( 0))) ))) ) << 16) | (  ((int)(((  ((int)(((0) << 4) | (0))) ) << 8) | (   ((int)(((0) << 4) | (0))) )))))) ;
            _cclass[16] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[17] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[18] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[19] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[20] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[21] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[22] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[23] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[24] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[25] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[26] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[27] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[28] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[29] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[30] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;
            _cclass[31] = ((int)(((  ((int)(((  ((int)((( 2) << 4) | (2)))  ) << 8) | (((int)(((2) << 4) | ( 2))) ))) ) << 16) | (  ((int)(((  ((int)(((2) << 4) | (2))) ) << 8) | (   ((int)(((2) << 4) | (2))) )))))) ;

            _states = new int[6] ;
            _states[0] = ((int)(((  ((int)(((  ((int)((( eStart) << 4) | (eStart)))  ) << 8) | (((int)(((eStart) << 4) | ( eStart))) ))) ) << 16) | (  ((int)(((  ((int)(((eStart) << 4) | (eError))) ) << 8) | (   ((int)(((     3) << 4) | (eStart))) )))))) ;
            _states[1] = ((int)(((  ((int)(((  ((int)((( eError) << 4) | (eError)))  ) << 8) | (((int)(((eError) << 4) | ( eError))) ))) ) << 16) | (  ((int)(((  ((int)(((eError) << 4) | (eError))) ) << 8) | (   ((int)(((eError) << 4) | (eError))) )))))) ;
            _states[2] = ((int)(((  ((int)(((  ((int)((( eItsMe) << 4) | (eItsMe)))  ) << 8) | (((int)(((eItsMe) << 4) | ( eItsMe))) ))) ) << 16) | (  ((int)(((  ((int)(((eItsMe) << 4) | (eItsMe))) ) << 8) | (   ((int)(((eItsMe) << 4) | (eItsMe))) )))))) ;
            _states[3] = ((int)(((  ((int)(((  ((int)(((      4) << 4) | (eError)))  ) << 8) | (((int)(((eError) << 4) | ( eError))) ))) ) << 16) | (  ((int)(((  ((int)(((     5) << 4) | (eError))) ) << 8) | (   ((int)(((eError) << 4) | (eError))) )))))) ;
            _states[4] = ((int)(((  ((int)(((  ((int)((( eError) << 4) | (eItsMe)))  ) << 8) | (((int)(((eError) << 4) | ( eItsMe))) ))) ) << 16) | (  ((int)(((  ((int)(((eError) << 4) | (eError))) ) << 8) | (   ((int)(((eError) << 4) | (eError))) )))))) ;
            _states[5] = ((int)(((  ((int)(((  ((int)((( eError) << 4) | (eError)))  ) << 8) | (((int)(((eItsMe) << 4) | ( eItsMe))) ))) ) << 16) | (  ((int)(((  ((int)(((eError) << 4) | (eError))) ) << 8) | (   ((int)(((eError) << 4) | (eError))) )))))) ;

            _charset =  "ISO-2022-JP";
            _stFactor =  8;
        }
        public override bool isUCS2() { return  false; }
    }
}
