// MeoL-API.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include "MeoL-API.h"


// This is an example of an exported variable
MEOLAPI_API int nMeoLAPI=0;

// This is an example of an exported function.
MEOLAPI_API int fnMeoLAPI(void)
{
    return 42;
}

// This is the constructor of a class that has been exported.
// see MeoL-API.h for the class definition
CMeoLAPI::CMeoLAPI()
{
    return;
}
