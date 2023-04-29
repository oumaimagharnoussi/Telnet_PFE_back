using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ticketback.Context;
using Ticketback.Models;

namespace Ticketback.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentaireController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public CommentaireController(AppDbContext appDbContext)
        {
            _authContext = appDbContext;
        }
        [HttpGet]
        public async Task<ActionResult<Commentaire>> GetAllCommentaires()
        {
            return Ok(await _authContext.Commentaires.ToListAsync());
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentaire(AddCommentaireRequest addCommentaireRequest)
        {
            var commentaire = new Commentaire()
            {

                libelle = addCommentaireRequest.libelle,
                userId = addCommentaireRequest.userId,

            };

            await _authContext.Commentaires.AddAsync(commentaire);
            await _authContext.SaveChangesAsync();



            return Ok(commentaire);
        }
        [HttpGet]
        [Route("{commentaireId:int}")]
        public async Task<IActionResult> GetCommentaire([FromRoute] int commentaireId)
        {
            var commentaire = await _authContext.Commentaires.FindAsync(commentaireId);
            if (commentaire == null)
            {
                return NotFound();
            }
            return Ok(commentaire);

        }
    }
}
