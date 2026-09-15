import './App.css'
import { EmployeesPage } from './EmployeesPage'
import { RoleProvider } from './RoleContext'

function App() {
  return (
    <RoleProvider>
      <EmployeesPage />
    </RoleProvider>
  )
}

export default App
