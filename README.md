# IT2media.Extensions.Object

# Sample

I often use LINQPad as a code scratchpad, but while copying code to a real implementation, I often had to remove lots of ".Dump()" commands, I usually use to output me something in LINQPad.  

So I made this little extension.

Dumps any object with .Dump() with Debug.WriteLine() as intended JSON with JSON.NET

```
public class MyPropertyTestClass
		{
			public string MyProperty
			{
				get;
				set;
			} = "MyPropertyTest2";

			public int MyProperty2
			{
				get;
				set;
			} = 4711;
		} ```
    
so if you Dump() this, this is the output to your Debug console:

```
{
  "MyProperty": "MyPropertyTest2",
  "MyProperty2": 4711
}
```
