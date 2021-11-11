using System;
using Prism.Mvvm;

namespace ERNITech.Models
{
    public class UserModel : BindableBase
    {
        // key: jrpro, datatype: int, property: Id
        private int _Id;
        [Newtonsoft.Json.JsonProperty("id")]
        public int Id { get { return _Id; } set { _Id = value; this.RaisePropertyChanged(nameof(Id)); } }

        // key: jrpro, datatype: string, property: Name
        private string _Name;
        [Newtonsoft.Json.JsonProperty("name")]
        public string Name { get { return _Name; } set { _Name = value; this.RaisePropertyChanged(nameof(Name)); } }

        // key: jrpro, datatype: string, property: Image
        private string _Image;
        [Newtonsoft.Json.JsonProperty("imageUrl")]
        public string Image { get { return _Image; } set { _Image = value; this.RaisePropertyChanged(nameof(Image)); } }
    }
}
