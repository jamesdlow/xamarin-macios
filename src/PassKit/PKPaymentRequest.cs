#nullable enable

using System;
using Foundation;
using ObjCRuntime;

namespace PassKit {

	public partial class PKContactFieldsExtensions {

		static public PKContactFields GetValue (NSSet set)
		{
			if (set is null)
				return PKContactFields.None;
			return PKContactFieldsExtensions.ToFlags (set.ToArray<NSString> ());
		}

		static public NSSet GetSet (PKContactFields values)
		{
			return new NSMutableSet (values.ToArray ());
		}
	}

	public partial class PKPaymentRequest {

#if NET
		[SupportedOSPlatform ("ios11.0")]
		[SupportedOSPlatform ("macos11.0")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
#else
		[Watch (4, 0)]
		[iOS (11, 0)]
#endif
		public PKContactFields RequiredBillingContactFields {
			get { return PKContactFieldsExtensions.GetValue (WeakRequiredBillingContactFields); }
			set { WeakRequiredBillingContactFields = PKContactFieldsExtensions.GetSet (value); }
		}

#if NET
		[SupportedOSPlatform ("ios11.0")]
		[SupportedOSPlatform ("macos11.0")]
		[SupportedOSPlatform ("maccatalyst")]
		[UnsupportedOSPlatform ("tvos")]
#else
		[Watch (4, 0)]
		[iOS (11, 0)]
#endif
		public PKContactFields RequiredShippingContactFields {
			get { return PKContactFieldsExtensions.GetValue (WeakRequiredShippingContactFields); }
			set { WeakRequiredShippingContactFields = PKContactFieldsExtensions.GetSet (value); }
		}
	}
}
