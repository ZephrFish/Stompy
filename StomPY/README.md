# StomPY
StomPY is the python implementation of Stompy, it uses standard built in python libs to perform MAC alterations on systems that might not support PS or C#. 

## Usage
To use StompyPy, you'll need to provide the path of the file or directory and the new timestamp. Additionally, you can use the -r or --recursive flag to indicate recursive processing of directories.

```
python stompy.py path/to/file_or_directory "MM/DD/YYYY" -r
```

Example:
```
python stompy.py ./documents "01/01/2020" --recursive
```

This command will modify the timestamps of all files in the ./documents directory (recursively) to January 1, 2020.
## Example
<img width="610" alt="image" src="https://github.com/ZephrFish/Stompy/assets/5783068/f08d6228-3b4b-4ea3-8ee2-8cb68c2e3d77">

## Limitations
- The script only modifies both the accessed and modified timestamps, not the created timestamp.
- Ensure you have appropriate permissions on the target files and directories.

