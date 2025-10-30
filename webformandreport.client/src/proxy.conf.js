const { env } = require('process');

// Determine backend target port
const target = env.ASPNETCORE_HTTPS_PORT
  ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}`
  : env.ASPNETCORE_URLS
    ? env.ASPNETCORE_URLS.split(';')[0]
    : 'https://localhost:7093'; // 👈 update this if your backend uses a different port

const PROXY_CONFIG = [
  {
    context: [
      "/api", // ✅ use this for all your API routes (Feedbacks, ProductReviews, etc.)
    ],
    target: target, // ✅ fix: you had an empty target
    secure: false
  }
];

module.exports = PROXY_CONFIG;
