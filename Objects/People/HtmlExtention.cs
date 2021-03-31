using System.IO;
using System.Text;

namespace Objects.People
{
	public static class HtmlExtentions
	{
		public static void HtmlFile(this Person person)
		{
			HtmlFile(new PeopleDatabase(person), person.FullName);
		}

		public static void HtmlFile(this PeopleDatabase database, string name = "database")
		{
			var directory = Directory.GetCurrentDirectory();
			var htmlFile = @"<!DOCTYPE html>
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
				htmlFile += (@"<tr>
			<td>" + database.Database[current].FullName + @"</td>
			<td>" + database.Database[current].BirthDay.ToShortDateString() + @"</td>
			<td>" + database.Database[current].PlaceOfBirth + @"</td>
			<td>" + database.Database[current].PassportId + @"</td>
			</tr>");
			}

			htmlFile += @"</table>
	         </body>
		</html>";
			using (var file = File.Open(directory + @"/" + @"/" + name + ".html",
				FileMode.OpenOrCreate))
			{
				var code = Encoding.Default.GetBytes(htmlFile);
				file.Write(code, 0, code.Length);
			}
		}
	}
}