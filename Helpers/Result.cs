using System.Collections.Generic;
using WebAPI.ResponseModel;

/* This class is created to display the word "Results" in the swagger response.
/ I wasn't quite sure enough if this was a special treatment, but in the pdf document I received from you,
/ in endpoint #2 'POST: /company/search' there is the word 'Results:' in the response storing a list of results.
/ This class could be redundant, but reading with understanding in my opinion it was necessary to add it. */

namespace WebAPI
{
	public class Result
	{
		public IEnumerable<CompanySearchResultResponse> Results { get; set; }
	}
}
