using System.IO;
using System.Linq;
using System.Text;

namespace Objects.People
{
	public static class HtmlExtentions
	{
		public static void HtmlDoc(this Person person)
		{
			HtmlDoc(new PeopleDatabase(person), person.FullName);
		}

		public static void HtmlDoc(this PeopleDatabase database, string name = "database")
		{
			var directory = Directory.GetCurrentDirectory();
			var htmlDoc = @"<!DOCTYPE html>
<html>
<head>
	<style>
	table {
		font-family: montserrat;
		border-collapse: collapse;
		margin: auto;     
		}
	td, th {
		border: 1px solid black;
		text-align: left;
		padding: 2px;
		}
	</style>
</head>
<body>
<table>
	<caption><b>Person Info</b></caption>
	<tr>
	<td> Full Name </td>
	<td> Date of Birth </td>
	<td> Place of Birth </td>
	<td> Passport ID </td>
	</tr>";
			foreach (var current in database.UsedPassportId)
			{
				htmlDoc += (@"<tr>
			<td>" + database.Database[current].FullName + @"</td>
			<td>" + database.Database[current].BirthDay.ToShortDateString() + @"</td>
			<td>" + database.Database[current].PlaceOfBirth + @"</td>
			<td>" + database.Database[current].PassportId + @"</td>
			</tr>");
			}

			htmlDoc += @"</table>
	         </body>
		</html>";
			using (var file = File.Open(directory + @"/" + @"/" + name + ".html",
				FileMode.OpenOrCreate))
			{
				var code = Encoding.Default.GetBytes(htmlDoc);
				object fileStream;
				file.Write(code, 0, code.Length);
			}
		}
	}
}