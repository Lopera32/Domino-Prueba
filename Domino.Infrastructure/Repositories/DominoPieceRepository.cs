using Domino.Core.DTOs;
using Domino.Core.Entities;
using Domino.Core.Interfaces;
using Domino.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace Domino.Infrastructure.Repositories
{
    public class DominoPieceRepository : IDominoRepository
    {
        private DominoContext _context;
        public DominoPieceRepository( DominoContext context)
        {
         
            _context = context;
        }


        public IEnumerable<DominoFullGame> GetDomino()
        {
            var dominoPieces = _context.dominoFullGames.ToList();

            return dominoPieces;
        }

        public List<DominoDto> CreateDominoFullGame(List<DominoDto> dominoChain)
        {
            var domino = CalculateGameChain(dominoChain);

            var dominoJson = JsonSerializer.Serialize(domino);

            if (dominoJson == null)
            {
                var dominoGame = new DominoFullGame { DominoGame = dominoJson, isValid = false, UserId = 1 };
                _context.Add(dominoGame);
                _context.SaveChanges();
                return domino;
            }
            else
            {
                var dominoGame = new DominoFullGame { DominoGame = dominoJson, isValid = true, UserId = 1 };
                _context.Add(dominoGame);
                _context.SaveChanges();
                return domino;
            }


        }
        public List<DominoDto> CalculateGameChain(List<DominoDto> dominoPiece)
        {
            //CAMBIAR DESDE ACA
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
        //CAMBIAR HASTA ACA


    }
}
