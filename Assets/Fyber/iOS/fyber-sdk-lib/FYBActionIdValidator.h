//
//
// Copyright (c) 2016 Fyber. All rights reserved.
//
//

@import Foundation;

FOUNDATION_EXPORT NSString *const FYBExceptionInvalidActionId;

@interface FYBActionIdValidator : NSObject

+ (BOOL)validate:(NSString *)actionId reasonForInvalid:(NSString **)reason;

+ (void)validateOrThrow:(NSString *)actionId;

@end
