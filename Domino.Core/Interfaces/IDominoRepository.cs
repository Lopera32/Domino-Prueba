using Domino.Core.DTOs;
using Domino.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domino.Core.Interfaces
{
    public interface IDominoRepository
    {
        Task<IEnumerable<DominoFullGame>> GetDominoPieces();
        List<DominoDto> CalculateChain(List<DominoDto> dominoPiece);
    }
}
