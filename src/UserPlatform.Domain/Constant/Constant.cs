﻿namespace UserPlatform.Domain.Constant
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

        #endregion

    }
}