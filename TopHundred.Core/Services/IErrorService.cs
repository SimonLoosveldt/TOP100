﻿namespace TopHundred.Core.Services
{
    public interface IErrorService
    {
        string ErrorMessage { get; }

        void ChangeMessage(string message);
        void DeleteMessage();
    }
}