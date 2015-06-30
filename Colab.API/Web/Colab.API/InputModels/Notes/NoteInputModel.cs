namespace Colab.API.InputModels.Notes
{
    using System.Runtime.Serialization;

    using Colab.Models;

    [DataContract]
    public class NoteInputModel
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        public Note ToEntity()
        {
            return new Note()
            {
                Body = this.Body,
                Title = this.Title
            };
        }
    }
}