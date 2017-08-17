// The following ifdef block is the standard way of creating macros which make exporting 
// from a DLL simpler. All files within this DLL are compiled with the MEOLAPI_EXPORTS
// symbol defined on the command line. This symbol should not be defined on any project
// that uses this DLL. This way any other project whose source files include this file see 
// MEOLAPI_API functions as being imported from a DLL, whereas this DLL sees symbols
// defined with this macro as being exported.
#ifdef MEOLAPI_EXPORTS
#define MEOLAPI_API __declspec(dllexport)
#else
#define MEOLAPI_API __declspec(dllimport)
#endif

// This class is exported from the MeoL-API.dll
class MEOLAPI_API CMeoLAPI {
public:
	CMeoLAPI(void);
	// TODO: add your methods here.
};

extern MEOLAPI_API int nMeoLAPI;

MEOLAPI_API int fnMeoLAPI(void);
