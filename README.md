# IT2media.Extensions.Object

I often use LINQPad as a code scratchpad, but while copying code to a real implementation, I often had to remove lots of ".Dump()" commands, I usually use to output me something in LINQPad.  

So I made this little extension.

Dumps any object with .Dump() with Debug.WriteLine() as intended JSON with JSON.NET

# Sample

Assume you have a object like this class:

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
		} 
```
    
so if you Dump() this like

```
MyPropertyTestClass instance = new MyPropertyTestClass();

instance.Dump();
```

this is the output to your Debug console:

```
{
  "MyProperty": "MyPropertyTest2",
  "MyProperty2": 4711
}
```
