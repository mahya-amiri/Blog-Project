import { Switch, Route } from "react-router-dom";
import PanelRoutes from "./PanelRoutes";
import PublicRoutes from "./PublicRoutes";
import AuthRoutes from "./AuthRoutes";

function Navigation() {
  return (
    <Switch>
      <Route path="/panel/">
        <PanelRoutes />
      </Route>
      <Route path="/auth/">
        <AuthRoutes />
      </Route>
      <Route path="/">
        <PublicRoutes />
      </Route>
    </Switch>
  );
}
export default Navigation;
