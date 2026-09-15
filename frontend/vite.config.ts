import react from '@vitejs/plugin-react'
import { defineConfig } from 'vite'

// https://vite.dev/config/
export default defineConfig({
  plugins: [react()],
  server: {
    proxy: {
      '/employees': 'http://localhost:5292',
      '/sites': 'http://localhost:5292',
      '/roles': 'http://localhost:5292',
    },
  },
})
