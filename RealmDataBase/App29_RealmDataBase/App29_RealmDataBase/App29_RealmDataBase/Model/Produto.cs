using Realms;
using System.ComponentModel.DataAnnotations;

namespace App29_RealmDataBase.Model
{
    public class Produto : RealmObject
    {
        [PrimaryKey]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Item { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [Range(1,999)]
        public int? Quantidade { get; set; }
    }
}
