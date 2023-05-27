﻿using DataLayer;

namespace WebApp.Models
{
	public class CartViewModel
	{
		public ICollection<ProductCart> ProductCartList { get; set; } = new List<ProductCart>();
		public Cart Cart { get; set; }= new Cart();
		public string? StreetName { get; set; }
		public FormFile FormFilePicture { get; set; }

	}
}
