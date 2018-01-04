# Synchro
Synchronize folders for Windows.

The Synchro control is a Visual Studio multithreaded user control allowing folder copy and synchronization. 
The control is visually a progress bar that can be added to a form. 
After its properties have been set, it can be launched by its method `SyncStart`. 
A separate thread is run so the program interface remains reactive. 
When it is done, it raises an event `SyncDone`. 
It may also be used in a console application, as a single thread.

The example application uses all the control properties and shows how to get information about the control status and treat the final event. 
It allows synchronizing several folders at the same time and saving parameters as documents. 
It runs both interactively or as a command line (see Help for the syntax). 
It was not written to replace Robocopy (from Windows Resource Kit) as a tool typically used in a scheduled task. 
_Synchro_ (the application) is, however, much easier to use by common people.

[More details and binaries](https://ericmarcon.github.io/Synchro/)
