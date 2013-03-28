using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManakinSkywalker.Web
{
	public class R2Data : DbContext
	{
		public virtual DbSet<Mapping> Mappings { get; set; }
	}

	public class Mapping
	{
		public virtual int Id { get; set; }
		public virtual string Verb { get; set; }
		public virtual string Url { get; set; }
		public virtual string Response { get; set; }
	}
}