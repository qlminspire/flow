import http from "k6/http"
import { sleep } from "k6"

import { API_SUBSCRIPTIONS_URL } from "./config"

export default function () {
	http.get(API_SUBSCRIPTIONS_URL)
	sleep(1)
}
