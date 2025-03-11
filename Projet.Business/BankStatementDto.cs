using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Projet.Business
{
	[XmlRoot("BankStatement")]
	public class BankStatementDto
	{
		[XmlElement("AccountNumber")]
		public string AccountNumber { get; set; }

		[XmlElement("Period")]
		public TransactionPeriodDto Period { get; set; }

		[XmlArray("Transactions")]
		[XmlArrayItem("Transaction")]
		public List<TransactionDto> Transactions { get; set; }
	}

	public class TransactionPeriodDto
	{
		[XmlElement("StartDate")]
		public DateTime StartDate { get; set; }

		[XmlElement("EndDate")]
		public DateTime EndDate { get; set; }
	}
}
