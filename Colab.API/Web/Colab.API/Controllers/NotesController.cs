namespace Colab.API.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Colab.API.DataTransferObjects.Note;
    using Colab.Data;

    public class NotesController : BaseApiController
    {
        public NotesController(IColabData data)
            : base(data)
        {
        }

        [HttpPost]
        public IHttpActionResult Create()
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
            return this.Ok();
        }
    }
}
