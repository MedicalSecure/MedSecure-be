public class CaeClaimsChallengeService
{
    public string? CheckForRequiredAuthContextIdToken(string authContextId, HttpContext context)
    {
        if (!string.IsNullOrEmpty(authContextId))
        {
            string authenticationContextClassReferencesClaim = "acrs";

            if (context == null || context.User == null || context.User.Claims == null || !context.User.Claims.Any())
            {
                throw new ArgumentNullException(nameof(context), "No Usercontext is available to pick claims from");
            }

            var acrsClaim = context.User.FindAll(authenticationContextClassReferencesClaim).FirstOrDefault(x => x.Value == authContextId);

            if (acrsClaim?.Value != authContextId)
            {
                var cae = "{\"id_token\":{\"acrs\":{\"essential\":true,\"value\":\"" + authContextId + "\"}}}";
                return cae;
            }
        }

        return null;
    }
}