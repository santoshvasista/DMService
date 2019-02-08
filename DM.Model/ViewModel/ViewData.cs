using System;
using System.Collections.Generic;
using System.Text;
using DM.Model.Interfaces;

namespace DM.Model.ViewModel
{
    public class ViewData : IViewModel
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
    public class MultiSelectViewData : IMultiViewData
    {
        public string Label { get; set; }
        public Guid? Value { get; set; }
    }
    public class CommunicationData:ViewData
    {
        public Guid? SmsCommunicationTypeId { get; set; }
        public Guid? EmailCommunicationTypeId { get; set; }
    }
}
