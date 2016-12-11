//
//
// Copyright (c) 2016 Fyber. All rights reserved.
//
//

#import <Foundation/Foundation.h>

static NSString *const FyberErrorDomain = @"FyberErrorDomain";

typedef NS_ENUM(NSInteger, FYBErrorCode) {
    FYBErrorCodeSDKNoUserId                    = 0001,
    FYBErrorCodeSDKNoAppId                     = 0002,

    FYBErrorCodeNetworkNoConnection            = 1000,

    FYBErrorCodeRewardedVideoOSVersion         = 2000,
    FYBErrorCodeRewardedVideoNotReady          = 2001,
    FYBErrorCodeRewardedVideoNoOffers          = 2002,
    FYBErrorCodeRewardedVideoMediation         = 2003,
    FYBErrorCodeRewardedVideoLoading           = 2010,
    FYBErrorCodeRewardedVideoLoadingTimeout    = 2011,
    FYBErrorCodeRewardedVideoPlaying           = 2020,
    FYBErrorCodeRewardedVideoPlayTimeout       = 2021,
    FYBErrorCodeRewardedVideoInvalidJSResponse = 2030,

    FYBErrorCodeInterstitialOSVersion          = 3000,
    FYBErrorCodeInterstitialNotReady           = 3001,
    FYBErrorCodeInterstitialNoOffers           = 3002,
    FYBErrorCodeInterstitialRequesting         = 3010,
    FYBErrorCodeInterstitialRequestingTimeout  = 3011,
    FYBErrorCodeInterstitialJSON               = 3012,
    FYBErrorCodeInterstitialServer             = 3013,
    FYBErrorCodeInterstitialInvalidOffer       = 3020,
    FYBErrorCodeInterstitialShowing            = 3030,
    FYBErrorCodeInterstitialPreload            = 3031,
    FYBErrorCodeInterstitialVideoTimeout       = 3100,

    FYBErrorCodeOfferWallNoUserId              = 4001,
    FYBErrorCodeOfferWallNoAppId               = 4002,
    FYBErrorCodeOfferWallLoading               = 4010,

    FYBErrorCodeMediationOther                 = 5000,
    FYBErrorCodeMediationSDK                   = 5001,
    FYBErrorCodeMediationInvalidConfiguration  = 5002,
    FYBErrorCodeMediationNoFill                = 5003,
    FYBErrorCodeMediationServer                = 5004,
    FYBErrorCodeMediationNetwork               = 5005,
    FYBErrorCodeMediationAdTimeOut             = 5006,
    FYBErrorCodeMediationNoPlacementId         = 5007,

    FYBErrorCodeBannerNotReady                 = 6001,
    FYBErrorCodeBannerNoOffers                 = 6002,
    FYBErrorCodeBannerInvalidSize              = 6003,
    FYBErrorCodeBannerRequesting               = 6010,
    FYBErrorCodeBannerRequestingTimeout        = 6011,

    FYBErrorCodeExternalStoreKit               = 9000
};
