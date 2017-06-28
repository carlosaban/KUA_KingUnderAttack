using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUA.LOGIC.Pieces
{
    public class EmptyPiece : BasePiece
    {

        public EmptyPiece(): base(){
            
            
            }
        public override BasePiece KingIsInCheck(ChessBoard chessBoard)
        {
            return null;
        }
    }
}
