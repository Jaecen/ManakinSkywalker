using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ManakinSkywalker.Web
{
	public class HandlerSolo : IHttpHandler
	{
		public bool IsReusable
		{ get { return true; } }

		public void ProcessRequest(HttpContext context)
		{
			R2Data dataContext = new R2Data();
			dataContext.Database.CreateIfNotExists();

			var response = dataContext.Mappings
				.Where(m => m.Verb == context.Request.HttpMethod)
				.ToArray()
				.Where(m => new Regex(m.Url).IsMatch(context.Request.AppRelativeCurrentExecutionFilePath))
				.Select(m => m.Response)
				.FirstOrDefault();

			if(response == null)
			{
				context.Response.StatusCode = 404;
				context.Response.End();
			}

			context.Response.StatusCode = 200;
			context.Response.Write(response);
			context.Response.End();
		}
	}
}