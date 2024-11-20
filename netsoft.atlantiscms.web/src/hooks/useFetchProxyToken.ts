// e.g., for MyconianMP
// url/login?code=MyconianMP

import { useState, useEffect } from "react";
import { useLocation, useNavigate } from "react-router-dom";

export const useFetchProxyToken = () => {
  const location = useLocation();
  const navigate = useNavigate();
  const queryParameters = new URLSearchParams(location.search);
  const code = queryParameters.get("code");
  const [token, setToken] = useState<string | null>(null);

  useEffect(() => {
    if (!code || code.trim() === "") {
      navigate("/error");
      return;
    }

    fetch(`https://proxy.spaonline.gr/api/login`, {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify({
        UserName: "atlantis",
        Password: "76d3da81-b919-4af1-b491-c5cb313cfb6c",
        PropertyCode: code,
      }),
    })
      .then((response) => {
        if (!response.ok) {
          throw new Error("Network response was not ok");
        }
        return response.json();
      })
      .then((data) => {
        console.log("Success:", data);
        localStorage.setItem("ProxyToken", data.Token);
        setToken(data.Token);
      })
      .catch((error) => {
        console.error("Error:", error);
        navigate("/error");
      });
  }, [code, navigate]);

  return token;
};
