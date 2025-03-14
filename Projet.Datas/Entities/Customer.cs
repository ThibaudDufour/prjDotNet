﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Projet.Datas.Entities
{
	public abstract class Customer
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[MaxLength(50)]
		public string Name { get; set; }
		public string Label { get; set; }
		public string? AdditionalInfo { get; set; }
		public string PostalCode { get; set; }
		public string City { get; set; }
		public string Email { get; set; }

		[NotMapped]
		public string FullAddress => $"{Label} {AdditionalInfo}, {PostalCode} {City}";

		public List<Account> Accounts { get; set; }
	}
}
