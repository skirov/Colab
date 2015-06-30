namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Note;
    using Colab.API.InputModels.Notes;
    using Colab.Data;

    using Microsoft.AspNet.Identity;

    public class NotesController : BaseApiController
    {
        public NotesController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create([FromBody]NoteInputModel inputModel)
        {
            return this.Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = this.Data.Notes
                             .All()
                             .Select(NoteDto.ToDto)
                             .ToList();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Delete(int id)
        {
            var note = this.Data.Notes.All().FirstOrDefault(x => x.Id == id);
            if (note == null)
            {
                return this.NotFound();
            }

            var currentUserId = this.User.Identity.GetUserId();
            if (note.CreatorId != currentUserId)
            {
                return this.Unauthorized();
            }

            this.Data.Notes.Delete(note);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}
