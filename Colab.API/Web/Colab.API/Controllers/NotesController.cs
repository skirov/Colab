namespace Colab.API.Controllers
{
    using Colab.Data;

    public class NotesController : BaseApiController
    {
        public NotesController(IColabData data)
            : base(data)
        {
        }
    }
}
