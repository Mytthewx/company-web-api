using System.Collections.Generic;
using WebAPI.ResponseModel;

/* Ta klasa stworzona jest po to, żeby wyświetlać napis "Results" w odowiedzi na swaggerze.
 * Nie byłem do końca pewny czy to jest zabieg specjalny, ale w dokumencie pdf jaki od Państwa otrzymałem,
 * w końcówce nr 2 'POST: /company/search' jest w odpowiedzi słowo "Results:" przechowujące listę wyników.
 * Ta klasa mogłaby być zbędna, ale czytając ze zrozumieniem według mnie konieczne było jej dodanie. */

namespace WebAPI
{
	public class Result
	{
		public IEnumerable<CompanySearchResultResponse> Results { get; set; }
	}
}
