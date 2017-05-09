# IT2media.Extensions.Object

I often use LINQPad as a code scratchpad, but while copying code to a real implementation, I often had to remove lots of ".Dump()" commands, I usually use to output me something in LINQPad.  

So I made this little extension.

Dumps any object with .Dump() with Debug.WriteLine() as intended JSON with JSON.NET

## Sample

Assume you have a object like this class:

```cs
public class SampleClass
{
	public string StringProperty
	{
		get;
		set;
	}

	public int IntProperty
	{
		get;
		set;
	}
} 
```
    
so if you Dump() this like

```
SampleClass instance = new SampleClass();

instance.Dump();
```

this is the output to your Debug console:

```js
{
  "StringProperty": null,
  "IntProperty": 0
}
```

## Redirect Debug to Console

On platforms where the *Console* is available you can redirect the *Debug* output to the console with:

```cs
TextWriterTraceListener[] listeners = { new TextWriterTraceListener(Console.Out) };
Debug.Listeners.AddRange(listeners);
```

## DumpToFile

DumpToFile and DumpToFileAsync are using PCLStorage for writing and so are writing to (in windows 10 at least) to %USERPROFILE%\AppData\Local
into a subfolder of your company/programname or programname/programname if no company is entered

If filename is null there is one generated with DateTime.Now.Ticks + ".json" extension.