using System;

namespace IMS.DataModel.Common
{
    public class SelectedItemModel
    {
        public SelectedItemModel()
        {

        }

        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool Selected { get; set; }
    }
}
