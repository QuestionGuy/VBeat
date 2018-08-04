﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VBeat.Models.BridgeModel;

namespace VBeat.Models
{
    public class ArtistModel : UserModel
    {
        public virtual ICollection<ArtistSongModel> SongList { get; } = new List<ArtistSongModel>();

        [Required]
        [Display(Name ="Artist Name")]
        [StringLength(20 ,MinimumLength=3)]
        public string ArtistName { get; set; }

        public string ArtistImage { get; set; }

        public virtual ICollection<ShowModel> Shows { get; set; }
    }
}
