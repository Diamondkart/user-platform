namespace UserPlatform.Domain.Constant
{
    public static class Constant
    {
        public const string ConnectionStringName = "UserAppConn";
        public const string MobileNumberPattern = @"^\d{10}$";
        public const string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
        public const string InvalidTokenKey = "Invalid Token";

        #region Validation Error Mesaage

        public const string UnAuthorizeErrorMessage = "Unauthorized access!";
        public const string EmptyUserNameErrorMessage = "UserName must have at least 3 characters.";
        public const string InvalidEmailErrorMessage = "Invalid email address.";
        public const string EmptyEmailErrorMessage = "Email can not be empty.";
        public const string InvalidMobileErrorMessage = "Mobile number should be 10 digits.";
        public const string EmptyMobileErrorMessage = "MobileNo can not be empty.";
        public const string EmptyPasswordErrorMessage = "Password can not be empty.";
        public const string EmptyFirstNameErrorMessage = "FirstName can not be empty.";
        public const string RecordExistsErrorMessage = "Same record already exists.";
        public const string InternalServerErrorMessage = "Internal server error!";
        public const string NotImplementedErrorMessage = "The requested functionality is not implemented.";
        public const string UnableToUpdateNumber = "Unable to update phone number.";
        public const string UnableToUpdateName = "Unable to update name.";
        public const string UserIdNotFound = "User With {0} not found";
        public const string InvalidUserNameOrPassword = "Either UserName or Password is invalid.";
        public const string InvalidToken = "Invalid token";
        public const string InvalidTokenOrTokenNotFOund = "Invalid token or no token found";
        public const string TokenExpired = "Token expired";
        public const string UserNameNotFound = "User Name With {0} not found";

        #endregion Validation Error Mesaage
    }
}