using System.IO;
using System.Text;

namespace Objects.People
{
	public static class HtmlExtensions
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
			foreach (var current in database.Database)
			{
				htmlFile += (@"<tr>
			<td>" + current.Value.FullName + @"</td>
			<td>" + current.Value.BirthDay.ToShortDateString() + @"</td>
			<td>" + current.Value.PlaceOfBirth + @"</td>
			<td>" + current.Value.PassportId + @"</td>
			</tr>");
			}

			htmlFile += @"</table>
	         </body>
		</html>";
			using var file = File.Open(Path.Combine(directory,name + ".html"),
				FileMode.OpenOrCreate);
			var code = Encoding.Default.GetBytes(htmlFile);
			file.Write(code, 0, code.Length);
		}
	}
}