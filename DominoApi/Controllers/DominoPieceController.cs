using AutoMapper;
using Domino.Core.DTOs;
using Domino.Core.Entities;
using Domino.Core.Interfaces;
using Domino.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Domino.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DominoPieceController : ControllerBase
    {
        private readonly IDominoRepository _dominoPieceRepository;
        private readonly IMapper _mapper;
        public DominoPieceController(IDominoRepository dominoPieceRepository, IMapper mapper)
        {
            _dominoPieceRepository = dominoPieceRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dominoPieces = await _dominoPieceRepository.GetDominoPieces();
            var dominoPiecesDto = _mapper.Map<IEnumerable<DominoDto>>(dominoPieces);
            return Ok(dominoPiecesDto);
        }


        [HttpPost]

        public ActionResult<List<DominoDto>> CreateDominoPiece(List<DominoDto> dominoPiece)
        {
           
            if (dominoPiece.Count < 2 || dominoPiece.Count > 6)
            {
                return BadRequest("El conjunto de fichas debe tener entre 2 y 6 fichas");
            }

            var domino = _dominoPieceRepository.CalculateChain(dominoPiece);

            if(domino == null)
            {
                return Ok("No es valido el juego de domino");
            }
            else
            {

                return Ok (domino);
            }
            

        }
    }


}
