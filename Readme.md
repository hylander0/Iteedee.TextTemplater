##Iteedee Text Templater

This is a very simple library that swaps placeholders with values found in your defined template.

For example take an **HTML Template** as such:

	<html>
		<head>
			<title>{%DYNAMIC_TITLE%}</title>
		</head>
		<Body>
			<p>
				{%HELLO_WORLD_VALUE%}
			</p>
		</Body>
	</html>


And have a **Dictionary** of template values (this is just a pseudo code showing the data of the .NET Dictionary):

	[
		{
			key : "DYNAMIC_TITLE",
			value : "My Template Title"
		},
		{
			key : "HELLO_WORLD_VALUE",
			value : "Hello my great big world"
		},
	]

Take your **HTML Template** and your **Dictionary** and call `PopulateTemplate`:

	Iteedee.TextTemplater.Templify.PopulateTemplate(Template, dictionaryData);

And you get:

	<html>
		<head>
			<title>My Template Title</title>
		</head>
		<Body>
			<p>
				Hello my great big world
			</p>
		</Body>
	</html>


###Great for:

* **Generating customized email bodys.**
* **Dynamically rendering specialized xml files.**
* **Very simple find and replace routines.**
