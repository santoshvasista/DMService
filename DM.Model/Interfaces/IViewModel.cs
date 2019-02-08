using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Model.Interfaces
{
    public interface IViewModel
    {
        bool IsSuccess { get; set; }
        string Message { get; set; }
    }

    public interface IMultiViewData
    {
        string Label { get; set; }
        Guid? Value { get; set; }
    }
    public interface ICommunicationViewData
    {
        Guid SmsCommunicationTypeId { get; set; }
        Guid EmailCommunicationTypeId { get; set; }
    }
}

