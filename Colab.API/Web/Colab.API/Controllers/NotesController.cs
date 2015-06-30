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
            var currentUserId = this.User.Identity.GetUserId();
            var entity = inputModel.ToEntity();
            entity.CreatorId = currentUserId;

            this.Data.Notes.Add(entity);
            this.Data.SaveChanges();

            return this.Ok(entity);
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var result = this.Data.Notes
                             .All()
                             .Where(x => x.CreatorId == currentUserId)
                             .Select(NoteDto.ToDto)
                             .ToList();

            return this.Ok(result);
        }

        [HttpPost]
        public IHttpActionResult Delete([FromBody]NoteDto inputModel)
        {
            var note = this.Data.Notes.All().FirstOrDefault(x => x.Id == inputModel.Id);
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
