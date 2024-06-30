import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

const proxyTarget: string = 'http://localhost:5272';
// https://vitejs.dev/config/
export default defineConfig({
  plugins: [react()],
  css: {
    preprocessorOptions: {
      less: {
        math: 'always',
        relativeUrls: true,
        javascriptEnabled: true,
        mode: 'local'
      }
    },
    modules: {}
  },
  server: {
    //settings dev local server
    host: 'localhost',
    port: 3000,
    https: false,
    open: true,

    // settings proxy server
    proxy: {
      '/api': {
        target: proxyTarget,
        changeOrigin: true,
        cookieDomainRewrite: 'localhost',
        secure: false
      },
    }
  }
})
