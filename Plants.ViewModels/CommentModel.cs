namespace Plants.ViewModels
{
    using static Services.Constants.GlobalConstants.CommentConstants;
    using static Services.Constants.GlobalConstants.ErrorMessages;

    using System.ComponentModel.DataAnnotations;

    public class CommentModel
    {
        [StringLength(CommentContentMaxLenght, MinimumLength = CommentContentMinLenght,
          ErrorMessage = StringLenghtErrorMessage)]
        public string Content { get; set; } = string.Empty;
    }
}
