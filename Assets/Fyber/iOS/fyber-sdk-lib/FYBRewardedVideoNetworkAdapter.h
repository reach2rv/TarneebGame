//
//
// Copyright (c) 2016 Fyber. All rights reserved.
//
//

#import <Foundation/Foundation.h>

@protocol FYBRewardedVideoNetworkAdapterDelegate;
@class FYBBaseNetwork;

/**
 * Defines the interface required by a video network SDK wrapper
 */
@protocol FYBRewardedVideoNetworkAdapter<NSObject>

/**
 * Delegates implementing the FYBVideoNetworkAdapterDelegate protocol that will get notified of
 * events in the lifecycle of the network adapter
 */
@property (nonatomic, weak) id<FYBRewardedVideoNetworkAdapterDelegate> delegate;

/**
 * Returns the name of the wrapped video network
 */
- (NSString *)networkName;

/**
 * Initializes the SDK with the given data
 */
- (BOOL)startAdapterWithDictionary:(NSDictionary *)dict;

/**
 * Checks whether there are videos available to start playing. This is expected
 * to be asynchronous, and the answer should be delivered through the
 * -adapter:didReportVideoAvailable: delegate method
 */
- (void)checkAvailability;

/**
 * Instructs the wrapped video network SDK to start playing a video
 *
 * @param parentVC If the wrapped SDK needs a parent UIViewController to which attach its own video player view controller to, it can use the provided one
 */
- (void)playVideoWithParentViewController:(UIViewController *)parentVC;

- (void)setNetwork:(FYBBaseNetwork *)network;

@end
