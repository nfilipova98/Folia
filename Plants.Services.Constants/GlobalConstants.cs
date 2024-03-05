namespace Plants.Services.Constants
{
	public class GlobalConstants
	{
		public static class PlantConstants
		{
			public const int PlantNameMinLenght = 3;
			public const int PlantNameMaxLenght = 70;
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

		public static class CityConstants
		{
			public const int CityNameMinLenght = 1;
			public const int CityNameMaxLenght = 165;
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
		}
	}
}
