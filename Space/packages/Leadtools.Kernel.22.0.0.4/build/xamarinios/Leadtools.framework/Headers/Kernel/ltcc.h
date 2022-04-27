//*************************************************************
// Copyright (c) 1991-2021 LEAD Technologies, Inc.
// All Rights Reserved.
//*************************************************************

#if !defined(LTCC_H)
#define LTCC_H

#include "ltprimitives.h"
#define L_LTCC_API LT_EXPORTED

#include "lterr.h"
#include "ltkrn.h"

#define L_HEADER_ENTRY
#include "ltpck.h"

/****************************************************************
Enums/defines/macros
****************************************************************/
//#define L_CC_MaxExpiryFutureYears 15

enum L_CC_CardType
{
   L_CC_CardType_Unknown, // Unknown card type.
   L_CC_CardType_InsufficientDigits, // More digits are required to know the card type. (e.g. all we have is a 3, so we don't know if it's JCB or AmEx)
   L_CC_CardType_AmericanExpress, // American Express cards start in 34 or 37
   L_CC_CardType_DinersClub, // Diners Club
   L_CC_CardType_Discover, // Discover starts with 6x for some values of x.
   L_CC_CardType_JCB, // JCB (see http://www.jcbusa.com/) cards start with 35
   L_CC_CardType_MasterCard, // MasterCard starts with 51-55
   L_CC_CardType_Visa, // Visa starts with 4
   L_CC_CardType_Maestro // Maestro
};
typedef enum L_CC_CardType L_CC_CardType;

enum L_CC_FrameOrientation
{
   L_CC_FrameOrientation_Portrait,
   L_CC_FrameOrientation_PortraitUpsideDown,
   L_CC_FrameOrientation_LandscapeLeft,
   L_CC_FrameOrientation_LandscapeRight
};
typedef enum L_CC_FrameOrientation L_CC_FrameOrientation;

enum L_CC_ScanFrameStatus
{
   L_CC_ScanFrameStatus_MoreFramesNeeded,
   L_CC_ScanFrameStatus_NumbersFound,
   L_CC_ScanFrameStatus_LowFocusScore,
   L_CC_ScanFrameStatus_Error
};
typedef enum L_CC_ScanFrameStatus L_CC_ScanFrameStatus;

enum L_CC_ImageFormat
{
   L_CC_ImageFormat_YUV420,
   L_CC_ImageFormat_YCbCr420,
   L_CC_ImageFormat_YCrCb420,
   L_CC_ImageFormat_RGB8888,
   L_CC_ImageFormat_BGR8888,
   L_CC_ImageFormat_RGB888,
   L_CC_ImageFormat_BGR888,
};
typedef enum L_CC_ImageFormat L_CC_ImageFormat;

// Scanner handle
L_DECLARE_HANDLE(L_CC_Scanner);

/****************************************************************
Data structures
****************************************************************/
// Scanner options (global or all frames)
struct L_CC_ScannerOptions
{
   L_UINT StructSize;
   L_BOOL DetectOnly; // Do not read the card value, just detect it. Default is L_FALSE
   L_BOOL DetectExpiryDate; // Detect the expiry date. Default value is L_TRUE
   L_FLOAT MinimumFocusScore; // The minimum focus score (from 0.0f to 10.0f). Default is 6.0f
};
typedef struct L_CC_ScannerOptions L_CC_ScannerOptions;

// Credit card (data read)
struct L_CC_CreditCard
{
   L_UINT StructSize;
   L_TCHAR CardNumber[32]; // 15 or 16 digit card number. All numbers, no spaces. NULL-terminated
   L_UINT ExpiryMonth; // Month in two digit natural form. {January=1, ..., December=12}
   L_UINT ExpiryYear; // Four digit year
   L_TCHAR CVV[8]; // Three or four character security code. NULL-terminated
   L_TCHAR PostalCode[32]; // Billing postal code for card. NULL-terminated
   L_CC_CardType CreditCardType; // The credit card type
};
typedef struct L_CC_CreditCard L_CC_CreditCard;

// Gets analytics about the current scan session
struct L_CC_ScannerAnalytics
{
   L_UINT StructSize;
   L_UINT FramesScannedCount;
};
typedef struct L_CC_ScannerAnalytics L_CC_ScannerAnalytics;

// Data for a frame (input)
struct L_CC_Frame
{
   L_UINT StructSize;
   L_INT Width; // Pixel width
   L_INT Height; // Pixel height, negative value indicates that the data is flipped (only for RGB/BGR formats).
   L_CC_FrameOrientation Orientation; // Orientation of this frame
   // Either
   L_CC_ImageFormat ImageFormat; // One of the supported image formats
   const L_UCHAR* ImageData; // Image data (in ImageFormat)
};
typedef struct L_CC_Frame L_CC_Frame;

struct L_CC_CornerPoints
{
   L_UINT StructSize;
   L_POINTD TopLeft;
   L_POINTD BottomLeft;
   L_POINTD TopRight;
   L_POINTD BottomRight;
};
typedef struct L_CC_CornerPoints L_CC_CornerPoints;

// Detected card info (output)
struct L_CC_DetectionInfo
{
   L_UINT StructSize;
   L_CC_ScanFrameStatus Status; // Status of last detection
   L_BOOL Flipped; // If the frame image data was flipped. Valid if Status = NumbersFound
   L_UINT YOffset; // Y-pixel of where the card numbers were found. Valid if Status = NumbersFound
   L_UINT XOffsets[16]; // X-pixel offsets of each card number. Valid if Status = NumbersFound
   L_UINT XOffsetsCount; // The number of offsets in XOffsets. Valid if Status = NumbersFound
   L_BOOL TopEdgeFound; // Top edge is found. Status could be NumbersFound or MoreFramesNeeded
   L_BOOL BottomEdgeFound; // Bottom edge is found. Status could be NumbersFound or MoreFramesNeeded
   L_BOOL LeftEdgeFound; // Left edge is found. Status could be NumbersFound or MoreFramesNeeded
   L_BOOL RightEdgeFound; // Right edge is found. Status could be NumbersFound or MoreFramesNeeded
   L_FLOAT FocusScore; // Current Focus score. Status could be NumbersFound or MoreFramesNeeded
   L_UINT Prediction[16]; // Current prediction (numbers). Valid if Status = NumbersFound
   L_UINT PredictionCount; // The number of predictions (numbers) in Prediction. Valid if Status = NumbersFound
   L_UINT ExpiryMonth; // Expiry date month (1 to 12). Valid if Status = NumbersFound
   L_UINT ExpiryYear; // Expire year (4 numbers). Valid if Status = NumbersFound
   L_BOOL CreateCardImage; // If TRUE and Status = NumbersFound, CardImage will be created from the frame image data
   BITMAPHANDLE* CardImage; // Will have the image of credit card from last frame. Valid if Status = MoreFramesNeeded or NumbersFound. User is responsible for freeing this image after each call to ScanFrame
   L_CC_CornerPoints CornerPoints; // The points at which the corners of the card were found in the image
};
typedef struct L_CC_DetectionInfo L_CC_DetectionInfo;

/****************************************************************
Function prototypes
****************************************************************/
// Create a new scanner with the specified options. options = NULL means use defaults
L_LTCC_API L_INT EXT_FUNCTION L_CC_CreateScanner(L_CC_Scanner* scanner, const L_CC_ScannerOptions* options);
// Destroys the scanner
L_LTCC_API L_INT EXT_FUNCTION L_CC_DestroyScanner(L_CC_Scanner scanner);
// Reset the scanner state
L_LTCC_API L_INT EXT_FUNCTION L_CC_ResetScanner(L_CC_Scanner scanner);
// Get the current scan analytics
L_LTCC_API L_INT EXT_FUNCTION L_CC_GetScannerAnalytics(L_CC_Scanner scanner, L_CC_ScannerAnalytics* analytics);
// Get the guide frame based on the client and preview height and width
L_LTCC_API L_INT EXT_FUNCTION L_CC_GetGuideFrame(L_UINT clientWidth, L_UINT clientHeight, L_UINT previewWidth, L_UINT previewHeight, L_RECT* frameRect);
// Add a frame, get results
L_LTCC_API L_INT EXT_FUNCTION L_CC_ScanFrame(L_CC_Scanner scanner, const L_CC_Frame* frame, L_CC_DetectionInfo* detectionInfo);
// Convert detection info to credit card
L_LTCC_API L_INT EXT_FUNCTION L_CC_ToCreditCard(const L_CC_DetectionInfo* detectionInfo, L_CC_CreditCard* creditCard);
// Get the credit card type from a number
L_LTCC_API L_INT EXT_FUNCTION L_CC_GetCardType(const L_TCHAR* cardNumber, L_CC_CardType* cardType);


#undef L_HEADER_ENTRY
#include "ltpck.h"

#endif // #if !defined(LTCC_H)
