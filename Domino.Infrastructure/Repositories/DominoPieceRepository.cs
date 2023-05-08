using Domino.Core.DTOs;
using Domino.Core.Entities;
using Domino.Core.Interfaces;
using Domino.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Domino.Infrastructure.Repositories
{
    public class DominoPieceRepository : IDominoRepository
    {
        private readonly DominoContext _context;
        public DominoPieceRepository(DominoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DominoFullGame>> GetDominoPieces()
        {
            var dominoPieces = await _context.dominoFullGames.ToListAsync();

            return dominoPieces;
        }

   


        public List<DominoDto> CalculateChain(List<DominoDto> dominoPiece)
        {
            var availableDominoPiece = new List<DominoDto>(dominoPiece);

            var chain = new List<DominoDto> { availableDominoPiece[0] };
            availableDominoPiece.RemoveAt(0);

            while (availableDominoPiece.Count > 0)
            {
                var matchFound = false;

                for (var i = 0; i < availableDominoPiece.Count; i++)
                {
                    if (chain[0].FirstValue == availableDominoPiece[i].SecondValue)
                    {
                        chain.Insert(0, availableDominoPiece[i]);
                        availableDominoPiece.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                    else if (chain[0].FirstValue == availableDominoPiece[i].FirstValue)
                    {
                        chain.Insert(0, availableDominoPiece[i]);
                        availableDominoPiece.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                }

                if (matchFound)
                {
                    continue;
                }

                for (var i = 0; i < availableDominoPiece.Count; i++)
                {
                    if (chain[chain.Count - 1].SecondValue == availableDominoPiece[i].FirstValue)
                    {
                        chain.Add(availableDominoPiece[i]);
                        availableDominoPiece.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                    else if (chain[chain.Count - 1].SecondValue == availableDominoPiece[i].SecondValue)
                    {
                        chain.Add(availableDominoPiece[i]);
                        availableDominoPiece.RemoveAt(i);
                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    return null;
                }
            }

            return chain;
        }



    }
}
