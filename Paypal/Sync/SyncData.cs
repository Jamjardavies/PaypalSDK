using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Paypal.Sync
{
    public class AuctionInformation
    {
        /// <summary>
        /// The ID of the buyer who makes the purchase in the auction. This ID might be different from the payer ID provided for the payment.
        /// </summary>
        [JsonProperty("auction_buyer_id")]
        public string AuctionBuyerId { get; set; }

        /// <summary>
        /// The date and time when the auction closes, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [JsonProperty("auction_closing_date")]
        public string AuctionClosingDate { get; set; }

        /// <summary>
        /// The auction site URL.
        /// </summary>
        [JsonProperty("auction_item_site")]
        public string AuctionItemSite { get; set; }

        /// <summary>
        /// The name of the auction site.
        /// </summary>
        [JsonProperty("auction_site")]
        public string AuctionSite { get; set; }
    }

    public class CartInformation
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public CartInformation() { }

        /// <summary>
        /// An array of item details.
        /// </summary>
        [JsonProperty("item_details")]
        public List<ItemDetails> ItemDetails { get; set; }

        /// <summary>
        /// The ID of the invoice. Appears only for PayPal-generated invoices.
        /// </summary>
        [JsonProperty("paypal_invoice_id")]
        public string PaypalInvoiceId { get; set; }

        /// <summary>
        /// Indicates whether the item amount or the shipping amount already includes tax.
        /// </summary>
        [JsonProperty("tax_inclusive")]
        public bool? TaxInclusive { get; set; }
    }

    public class CheckoutOption
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public CheckoutOption() { }

        /// <summary>
        /// The checkout option name, which is a characteristic of an item, such as `color` or `texture`.
        /// </summary>
        [JsonProperty("checkout_option_name")]
        public string CheckoutOptionName { get; set; }

        /// <summary>
        /// The checkout option value. For example, the checkout option `color` might be `blue` or `red` while the checkout option `texture` might be `smooth` or `rippled`.
        /// </summary>
        [JsonProperty("checkout_option_value")]
        public string CheckoutOptionValue { get; set; }
    }

    public class IncentiveDetails
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public IncentiveDetails() { }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("incentive_amount")]
        public Money IncentiveAmount;

        /// <summary>
        /// The code that identifies an incentive, such as a coupon.
        /// </summary>
        [JsonProperty("incentive_code")]
        public string IncentiveCode;

        /// <summary>
        /// The incentive program code that identifies a merchant loyalty or incentive program.
        /// </summary>
        [JsonProperty("incentive_program_code")]
        public string IncentiveProgramCode;

        /// <summary>
        /// The type of incentive, such as a special offer or coupon.
        /// </summary>
        [JsonProperty("incentive_type")]
        public string IncentiveType;
    }

    public class IncentiveInformation
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public IncentiveInformation() { }

        /// <summary>
        /// An array of incentive details.
        /// </summary>
        [JsonProperty("incentive_details")]
        public List<IncentiveDetails> IncentiveDetails { get; set; }
    }

    public class ItemDetails
    {
        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("adjustment_amount")]
        public Money AdjustmentAmount { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("basic_shipping_amount")]
        public Money BasicShippingAmount { get; set; }

        /// <summary>
        /// An array of checkout options. Each option has a name and value.
        /// </summary>
        [JsonProperty("checkout_options")]
        public List<CheckoutOption> CheckoutOptions { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("discount_amount")]
        public Money DiscountAmount { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("extra_shipping_amount")]
        public Money ExtraShippingAmount { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("gift_wrap_amount")]
        public Money GiftWrapAmount { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("handling_amount")]
        public Money HandlingAmount { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("insurance_amount")]
        public Money InsuranceAmount { get; set; }

        /// <summary>
        /// The invoice number. An alphanumeric string that identifies a billing for a merchant.
        /// </summary>
        [JsonProperty("invoice_number")]
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("item_amount")]
        public Money ItemAmount { get; set; }

        /// <summary>
        /// An item code that identifies a merchant's goods or service.
        /// </summary>
        [JsonProperty("item_code")]
        public string ItemCode { get; set; }

        /// <summary>
        /// The item description.
        /// </summary>
        [JsonProperty("item_description")]
        public string ItemDescription { get; set; }

        /// <summary>
        /// The item name.
        /// </summary>
        [JsonProperty("item_name")]
        public string ItemName { get; set; }

        /// <summary>
        /// The item options. Describes option choices on the purchase of the item in some detail.
        /// </summary>
        [JsonProperty("item_options")]
        public string ItemOptions { get; set; }

        /// <summary>
        /// The number of purchased units of goods or a service.
        /// </summary>
        [JsonProperty("item_quantity")]
        public string ItemQuantity { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("item_unit_price")]
        public Money ItemUnitPrice { get; set; }

        /// <summary>
        /// An array of tax amounts levied by a government on the purchase of goods or services.
        /// </summary>
        [JsonProperty("tax_amounts")]
        public List<Tax> TaxAmounts { get; set; }

        /// <summary>
        /// The percentage, as a fixed-point, signed decimal number. For example, define a 19.99% interest rate as `19.99`.
        /// </summary>
        [JsonProperty("tax_percentage")]
        public string TaxPercentage { get; set; }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("total_item_amount")]
        public Money TotalItemAmount { get; set; }
    }

    public class LinkDescription
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public LinkDescription() { }

        /// <summary>
        /// REQUIRED
        /// The complete target URL. To make the related call, combine the method with this [URI Template-formatted](https://tools.ietf.org/html/rfc6570) link. For pre-processing, include the `$`, `(`, and `)` characters. The `href` is the key HATEOAS component that links a completed call with a subsequent call.
        /// </summary>
        [JsonProperty("href")]
        public string Href;

        /// <summary>
        /// The HTTP method required to make the related call.
        /// </summary>
        [JsonProperty("method")]
        public string Method;

        /// <summary>
        /// REQUIRED
        /// The [link relation type](https://tools.ietf.org/html/rfc5988#section-4), which serves as an ID for a link that unambiguously describes the semantics of the link. See [Link Relations](https://www.iana.org/assignments/link-relations/link-relations.xhtml).
        /// </summary>
        [JsonProperty("rel")]
        public string Rel;
    }

    public class Money
    {
        /// <summary>
        /// REQUIRED
        /// The [three-character ISO-4217 currency code](/docs/integration/direct/rest/currency-codes/) that identifies the currency.
        /// </summary>
        [JsonProperty("currency_code")]
        public string CurrencyCode { get; set; }

        /// <summary>
        /// REQUIRED
        /// The value, which might be:<ul><li>An integer for currencies like `JPY` that are not typically fractional.</li><li>A decimal fraction for currencies like `TND` that are subdivided into thousandths.</li></ul>For the required number of decimal places for a currency code, see [Currency codes - ISO 4217](https://www.iso.org/iso-4217-currency-codes.html).
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public class Name
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public Name() { }

        /// <summary>
        /// The party's alternate name. Can be a business name, nickname, or any other name that cannot be split into first, last name. Required for a business party name.
        /// </summary>
        [JsonProperty("alternate_full_name")]
        public string AlternateFullName { get; set; }

        /// <summary>
        /// The party's given, or first, name. Required if the party is a person.
        /// </summary>
        [JsonProperty("given_name")]
        public string GivenName { get; set; }

        /// <summary>
        /// The party's middle name. Use also to store multiple middle names including the patronymic, or father's, middle name.
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        /// The prefix, or title, to the party name.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// The suffix for the party's name.
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        /// The party's surname or family name. Also known as the last name. Required if the party is a person. Use also to store multiple surnames including the matronymic, or mother's, surname.
        /// </summary>
        [JsonProperty("surname")]
        public string Surname { get; set; }
    }

    public class PayerInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayerInformation() { }

        /// <summary>
        /// The PayPal` customer account ID.
        /// </summary>
        [JsonProperty("account_id")]
        public string AccountId { get; set; }

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [JsonProperty("address")]
        public SimplePostalAddress Address { get; set; }

        /// <summary>
        /// The address status of the payer. Value is either:<ul><li><code>Y</code>. Verified.</li><li><code>N</code>. Not verified.</li></ul>
        /// </summary>
        [JsonProperty("address_status")]
        public string AddressStatus { get; set; }

        /// <summary>
        /// The [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The internationalized email address.<blockquote><strong>Note:</strong> Up to 64 characters are allowed before and 255 characters are allowed after the <code>@</code> sign. However, the generally accepted maximum length for an email address is 254 characters. The pattern verifies that an unquoted <code>@</code> sign exists.</blockquote>
        /// </summary>
        [JsonProperty("email_address")]
        public string EmailAddress { get; set; }

        /// <summary>
        /// The name of the party.
        /// </summary>
        [JsonProperty("payer_name")]
        public Name PayerName { get; set; }

        /// <summary>
        /// The status of the payer. Value is `Verified` or `Unverified`.
        /// </summary>
        [JsonProperty("payer_status")]
        public string PayerStatus { get; set; }

        /// <summary>
        /// The phone number, in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en).
        /// </summary>
        [JsonProperty("phone_number")]
        public Phone PhoneNumber { get; set; }
    }

    public class Phone
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public Phone() { }

        /// <summary>
        /// REQUIRED
        /// The country calling code (CC), in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en). The combined length of the CC and the national number must not be greater than 15 digits. The national number consists of a national destination code (NDC) and subscriber number (SN).
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The extension number.
        /// </summary>
        [JsonProperty("extension_number")]
        public string ExtensionNumber { get; set; }

        /// <summary>
        /// REQUIRED
        /// The national number, in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en). The combined length of the country calling code (CC) and the national number must not be greater than 15 digits. The national number consists of a national destination code (NDC) and subscriber number (SN).
        /// </summary>
        [JsonProperty("national_number")]
        public string NationalNumber { get; set; }
    }

    public class ShippingInformation
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public ShippingInformation() { }

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [JsonProperty("address")]
        public SimplePostalAddress Address { get; set; }

        /// <summary>
        /// The shipping method that is associated with this order.
        /// </summary>
        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// The recipient's name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [JsonProperty("secondary_shipping_address")]
        public SimplePostalAddress SecondaryShippingAddress { get; set; }
    }

    public class SimplePostalAddress
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SimplePostalAddress() { }

        /// <summary>
        /// REQUIRED
        /// The city name.
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        /// REQUIRED
        /// The [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// REQUIRED
        /// The first line of the address. For example, number, street, and so on.
        /// </summary>
        [JsonProperty("line1")]
        public string Line1 { get; set; }

        /// <summary>
        /// Optional. The second line of the address. For example, suite, apartment number, and so on.
        /// </summary>
        [JsonProperty("line2")]
        public string Line2 { get; set; }

        /// <summary>
        /// The postal code, which is the zip code or equivalent. Typically required for countries with a postal code or an equivalent. See [postal code](https://en.wikipedia.org/wiki/Postal_code).
        /// </summary>
        [JsonProperty("postal_code")]
        public string PostalCode { get; set; }

        /// <summary>
        /// The [code](/docs/integration/direct/rest/state-codes/) for a US state or the equivalent for other countries. Required for transactions if the address is in one of these countries: [Argentina](/docs/integration/direct/rest/state-codes/#argentina), [Brazil](/docs/integration/direct/rest/state-codes/#brazil), [Canada](/docs/integration/direct/rest/state-codes/#canada), [India](/docs/integration/direct/rest/state-codes/#india), [Italy](/docs/integration/direct/rest/state-codes/#italy), [Japan](/docs/integration/direct/rest/state-codes/#japan), [Mexico](/docs/integration/direct/rest/state-codes/#mexico), [Thailand](/docs/integration/direct/rest/state-codes/#thailand), or [United States](/docs/integration/direct/rest/state-codes/#usa). Maximum length is 40 single-byte characters.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        public override string ToString()
        {
            return $"{Line1} {Line2} {City} {State} {PostalCode} {CountryCode}";
        }
    }

    public class StoreInformation
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public StoreInformation() { }

        /// <summary>
        /// The ID of a store for a merchant in the system of record.
        /// </summary>
        [JsonProperty("store_id")]
        public string StoreId { get; set; }

        /// <summary>
        /// The terminal ID for the checkout stand in a merchant store.
        /// </summary>
        [JsonProperty("terminal_id")]
        public string TerminalId { get; set; }
    }

    public class Tax
    {
        /// <summary>
        /// Required default constructor
        /// </summary>
        public Tax() { }

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [JsonProperty("tax_amount")]
        public Money TaxAmount { get; set; }
    }

    public class TransactionDetails
    {
        [JsonProperty("auction_info")] public AuctionInformation AuctionInfo { get; set; }
        [JsonProperty("cart_info")] public CartInformation CartInfo { get; set; }
        [JsonProperty("incentive_info")] public IncentiveInformation IncentiveInfo { get; set; }
        [JsonProperty("payer_info")] public PayerInformation PayerInfo { get; set; }
        [JsonProperty("shipping_info")] public ShippingInformation ShippingInfo { get; set; }
        [JsonProperty("store_info")] public StoreInformation StoreInfo { get; set; }
        [JsonProperty("transaction_info")] public TransactionInformation TransactionInfo { get; set; }
        [JsonProperty("page")] public int Page { get; set; }
        [JsonProperty("total_pages")] public int TotalPages { get; set; }
    }

    public class TransactionInformation
    {
        [JsonProperty("annual_percentage_rate")] public string AnnualPercentageRate { get; set; }
        [JsonProperty("available_balance")] public Money AvailableBalance { get; set; }
        [JsonProperty("bank_reference_id")] public string BankReferenceId { get; set; }
        [JsonProperty("credit_promotional_fee")] public Money CreditPromotionalFee { get; set; }
        [JsonProperty("credit_term")] public string CreditTerm { get; set; }
        [JsonProperty("credit_transactional_fee")] public Money CreditTransactionalFee { get; set; }
        [JsonProperty("custom_field")] public string CustomField { get; set; }
        [JsonProperty("discount_amount")] public Money DiscountAmount { get; set; }
        [JsonProperty("ending_balance")] public Money EndingBalance { get; set; }
        [JsonProperty("fee_amount")] public Money FeeAmount { get; set; }
        [JsonProperty("insurance_amount")] public Money InsuranceAmount { get; set; }
        [JsonProperty("invoice_id")] public string InvoiceId { get; set; }
        [JsonProperty("other_amount")] public Money OtherAmount { get; set; }
        [JsonProperty("payment_method_type")] public string PaymentMethodType { get; set; }
        [JsonProperty("payment_tracking_id")] public string PaymentTrackingId { get; set; }
        [JsonProperty("paypal_account_id")] public string PaypalAccountId { get; set; }
        [JsonProperty("paypal_reference_id")] public string PaypalReferenceId { get; set; }
        [JsonProperty("paypal_reference_id_type")] public string PaypalReferenceIdType { get; set; }
        [JsonProperty("protection_eligibility")] public string ProtectionEligibility { get; set; }
        [JsonProperty("sales_tax_amount")] public Money SalesTaxAmount { get; set; }
        [JsonProperty("shipping_amount")] public Money ShippingAmount { get; set; }
        [JsonProperty("shipping_discount_amount")] public Money ShippingDiscountAmount { get; set; }
        [JsonProperty("shipping_tax_amount")] public Money ShippingTaxAmount { get; set; }
        [JsonProperty("tip_amount")] public Money TipAmount { get; set; }
        [JsonProperty("transaction_amount")] public Money TransactionAmount { get; set; }
        [JsonProperty("transaction_event_code")] public string TransactionEventCode { get; set; }
        [JsonProperty("transaction_id")] public string TransactionId { get; set; }
        [JsonProperty("transaction_initiation_date")] public DateTime TransactionInitiationDate { get; set; }
        [JsonProperty("transaction_note")] public string TransactionNote { get; set; }
        [JsonProperty("transaction_status")] public string TransactionStatus { get; set; }
        [JsonProperty("transaction_subject")] public string TransactionSubject { get; set; }
        [JsonProperty("transaction_updated_date")] public DateTime TransactionUpdatedDate { get; set; }
    }

    public class Transactions
    {
        [JsonProperty("account_number")] public string AccountNumber { get; set; }
        [JsonProperty("last_refreshed_datetime")] public string LastRefreshedDatetime { get; set; }
        [JsonProperty("links")] public List<LinkDescription> Links { get; set; }
        [JsonProperty("page")] public int? Page { get; set; }
        [JsonProperty("total_items")] public int? TotalItems { get; set; }
        [JsonProperty("total_pages")] public int TotalPages { get; set; }
        [JsonProperty("transaction_details")] public List<TransactionDetails> TransactionDetails { get; set; }
    }
}
