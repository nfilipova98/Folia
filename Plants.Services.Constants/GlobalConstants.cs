namespace Plants.Services.Constants
{
    public class GlobalConstants
    {
        public static class PlantConstants
        {
            public const int PlantNameMinLenght = 3;
            public const int PlantNameMaxLenght = 70;

            public const int PlantScientificNameMinLenght = 3;
            public const int PlantScientificNameMaxLenght = 100;

			public const int PlantDescriptionMinLenght = 10;
		}

        public static class PetConstants
        {
            public const int PetNameMinLenght = 3;
            public const int PetNameMaxLenght = 50;
        }

        public static class CommentConstants
        {
            public const int CommentContentMinLenght = 1;
            public const int CommentContentMaxLenght = 350;
        }

        public static class RegionConstants
        {
            public const int RegionNameMinLenght = 1;
            public const int RegionNameMaxLenght = 165;
        }

        public static class CountryConstants
        {
            public const int CountryNameMinLenght = 2;
            public const int CountryNameMaxLenght = 60;
        }

        public static class ErrorMessages
        {
            public const string RequiredErrorMessage = "The {0} field is required";
            public const string StringLenghtErrorMessage = "The {0} field must be between {2} and {1} characters";
            public const string CapitalLetter = "The {0} field must begin with one capital letter";
        }

        public static class ApiConstants
        {
            public const string BlobContainerName = "publicimages";
            public const int PastDays = 90;
        }

		public static class Paging
		{
			public const int ItemsPerPage = 12;
		}

        public static class AdminConstants
        {
            public const string Admin = "Admin";
            public const string AdminMail = "nfilipova@students.softuni.bg";
		}

		public static class DateConstant
		{
			public const string DateFormat = "dd/MM/yyyy HH:mm";
		}
	}
}
